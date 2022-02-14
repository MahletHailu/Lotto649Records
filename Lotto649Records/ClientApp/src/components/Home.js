import React, { Component } from 'react';
import {
    TextField,
    Grid,
    Box,
    List,
    ListItem,
    Button
  } from '@material-ui/core';

  import {
    Alert
  } from '@mui/material';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = {
            result: {
                matchedDraws: [],
                totalWon: 0,
                totalCost: 0,
            },
            number1: 0,
            number2: 0,
            number3: 0,
            number4: 0,
            number5: 0,
            number6: 0,  
            errornumber1: false,
            errornumber2: false,
            errornumber3: false,
            errornumber4: false,
            errornumber5: false,
            errornumber6: false,  
            alert: false,
            showResult: false     
        };

        this.processNumbers = this.processNumbers.bind(this);
        this.postData = this.postData.bind(this);  
        this.handleOnChange = this.handleOnChange.bind(this);     
    }

    processNumbers() {
        // Validate inputs

        // Check if all values are >0 and <= 49, users may click the button without even putting any values to the inputs.
        // In this case, your input validations won't catch empty inputs.

        if(
            this.state.number1 < 1 || this.state.number1 > 49 ||
            this.state.number2 < 1 || this.state.number2 > 49 || 
            this.state.number3 < 1 || this.state.number3 > 49 || 
            this.state.number4 < 1 || this.state.number4 > 49 ||  
            this.state.number5 < 1 || this.state.number5 > 49 || 
            this.state.number6 < 1 || this.state.number6 > 49 
        ){
            this.setState({alert: true});
        }
        else{
            this.setState({alert: false});
        }

        this.postData('api/Lotto649Records/ProcessNumbers',
            {
                "number1": this.state.number1,
                "number2": this.state.number2,
                "number3": this.state.number3,
                "number4": this.state.number4,
                "number5": this.state.number5,
                "number6": this.state.number6
            })
            .then(data => {
                this.setState({
                    result: data,
                    totalWon: 0,
                    totalCost: 0,
                });
                this.setState({showResult: true});

                // Handle error here
            });
    }

    async postData(url, data) {

        const response = await fetch(url, {
            method: 'POST',
            mode: 'cors',
            cache: 'no-cache',
            credentials: 'same-origin',
            headers: {
                'Content-Type': 'application/json',
            },
            redirect: 'follow',
            referrerPolicy: 'no-referrer',
            body: JSON.stringify(data)
        });

        //Handle error : to be done.
        return response.json();
    }

    handleOnChange(e) {
        // Get state name that represents error for the input control
        const errorNumber = 'error' + e.target.name;

        // Check if value is [1,49]
        if(e.target?.value < 1 || e.target?.value > 49){ 
            //If input is not valid, make error field for that input true.          
            this.setState({[errorNumber]: true});
        }
        else{
            //Check for duplicates
            if( (e.target?.value === this.state.number1 && e.target.name !== 'number1') ||
                (e.target?.value === this.state.number2 && e.target.name !== 'number2') ||
                (e.target?.value === this.state.number3 && e.target.name !== 'number3') ||
                (e.target?.value === this.state.number4 && e.target.name !== 'number4') ||
                (e.target?.value === this.state.number5 && e.target.name !== 'number5') ||
                (e.target?.value === this.state.number6 && e.target.name !== 'number6') 
                )
                {
                    // Duplicates not allowed
                    this.setState({[errorNumber]: true});   
                }
            else{
                //Save numbers in appropriate state
                this.setState({[errorNumber]: false});
                this.setState({[e.target.name]: e.target?.value});
            }
        }
      }

    render() {
        return (
            <div className="wrapper">
                <h1>Check your numbers</h1>

                <h6>Please enter Six numbers (between 1 and 49) below and we will check them against every 6/49 draw since 1981, and calculate your net winnings(or losings).</h6>
                <h6>Only numbers from 1 - 49 are valid. No duplicates are allowed.</h6>
                <Grid container  style ={{width: '70%', m:3 }}>
                    <Grid item xs={12} md={2}>
                    <TextField
                      required
                      error={this.state.errornumber1}
                      name="number1"
                      variant="outlined"
                      label="Number 1"
                      size="small"
                      style ={{width: '100px'}}
                      onChange={this.handleOnChange}
                    />
                    </Grid>
                    <Grid item xs={12} md={2}>
                      <TextField
                        required
                        error={this.state.errornumber2}
                        name="number2"
                        variant="outlined"
                        label="Number 2"
                        size="small"
                        style ={{width: '100px'}}
                        onChange={this.handleOnChange}
                      />
                    </Grid>
                   <Grid item xs={12} md={2}>
                    <TextField
                        required
                        error={this.state.errornumber3}
                        name="number3"
                        variant="outlined"
                        label="Number 3"
                        size="small"
                        style ={{width: '100px'}}
                        onChange={this.handleOnChange}
                     />
                    </Grid>
                  <Grid item xs={12} md={2}>
                    <TextField
                        required
                        error={this.state.errornumber4}
                        name="number4"
                        variant="outlined"
                        label="Number 4"
                        size="small"
                        style ={{width: '100px'}}
                        onChange={this.handleOnChange}
                    />
                  </Grid>
                  <Grid item xs={12} md={2}>
                    <TextField
                        required
                        error={this.state.errornumber5}
                        name="number5"
                        variant="outlined"
                        label="Number 5"
                        size="small"
                        style ={{width: '100px'}}
                        onChange={this.handleOnChange}
                    />
                  </Grid>
                  <Grid item xs={12} md={2}>
                    <TextField
                        required
                        error={this.state.errornumber6}
                        name="number6"
                        variant="outlined"
                        label="Number 6"
                        size="small"
                        style ={{width: '100px'}}
                        onChange={this.handleOnChange}
                    />
                 </Grid>   
                </Grid>
                <Box
                 sx={{ mt: 4 }}
                > 
                   <Button 
                      color="primary"
                      variant="contained" 
                      disabled={
                        this.state.errornumber1||
                        this.state.errornumber2||
                        this.state.errornumber3||
                        this.state.errornumber4||
                        this.state.errornumber5||
                        this.state.errornumber6
                        }
                      onClick={this.processNumbers}
                    >
                     Check the Numbers
                    </Button>
                    {this.state.alert &&  <Box
                        sx={{ mt: 3 }}
                    > 
                      <Alert 
                        severity="error"
                      >
                        Values can only be from 1 - 46. Each number has to be unique.
                     </Alert>
                    </Box>}
                </Box>
                {(this.state.showResult) && <Box
                  sx={{ mt: 4 }}
                >
                    <List>
                        <ListItem>
                        <div 
                            style={{
                                display: 'block',
                            }}>
                                {this.state.result?.matchedDraws?.map((m) =>
                            <div>
                                {m.drawDate} won ${m.won}
                            </div>
                            )}
                        </div>
                        </ListItem>
                    </List>
                    <div 
                        style={{
                            display: 'block',
                            paddingLeft:'20px'
                        }}> 
                        <div>Total won: ${this.state.result?.totalWon}</div>
                        <div>You spent: ${this.state.result?.totalCost}</div>
                        <div>Net won/loss: ${this.state?.result?.totalWon > this.state?.result?.totalCost 
                            ? this.state?.result?.totalWon - this.state?.result?.totalCost
                            : this.state?.result?.totalCost - this.state?.result?.totalWon}
                        </div>
                    </div>
                </Box>}
            </div>
        );
    }
}
