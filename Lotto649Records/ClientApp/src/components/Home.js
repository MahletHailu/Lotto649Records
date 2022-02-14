import React, { Component } from 'react';
import {
    TextField,
    Grid,
    Box,
    List,
    ListItem
  } from '@material-ui/core';

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
        };
        this.processNumbers = this.processNumbers.bind(this);
        this.postData = this.postData.bind(this);       
    }

    componentDidMount() {
        this.handleOnChange = this.handleOnChange(this);
      }

    processNumbers() {
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

                console.log(this.state.result?.totalWon);
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
        return response.json();
    }

    handleOnChange = (e) => {
        this.setState({number1: e.target?.value});
      }

    render() {
        return (
            <div className="wrapper">
                <h1>Check your numbers</h1>

                <h6>Please enter Six numbers (between 1 and 49) below and we will check them against every 6/49 draw since 1981, and calculate your net winnings(or losings).</h6>
                <Grid container >
                    <Grid item xs={12} md={2}></Grid>
                    <TextField
                        label="Number1"
                        onChange={e =>  {this.setState({number1: e.target?.value}); }}
                        />
                    <Grid item xs={12} md={2}></Grid>
                    <TextField
                        label="Number2"
                        onChange={e =>  {this.setState({number2: e.target?.value}); }}
                        />
                   <Grid item xs={12} md={2}></Grid>
                    <TextField
                        label="Number3"
                        onChange={e =>  {this.setState({number3: e.target?.value}); }}
                        />
                  <Grid item xs={12} md={2}></Grid>
                    <TextField
                        label="Number4"
                        onChange={e =>  {this.setState({number4: e.target?.value}); }}
                        />
                  <Grid item xs={12} md={2}></Grid>
                    <TextField
                        label="Number5"
                        onChange={e =>  {this.setState({number5: e.target?.value}); }}
                        />
                  <Grid item xs={12} md={2}></Grid>
                    <TextField
                        label="Number6"
                        onChange={e =>  {this.setState({number6: e.target?.value}); }}
                        />
                </Grid>
                <button className="btn btn-primary" onClick={this.processNumbers}>Check the Numbers</button>
                <Box>
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
                        }}> 
                        <div>Total won: {this.state.result?.totalWon}</div>
                        <div>You spent: {this.state.result?.totalCost}</div>
                    </div>
                </Box>
            </div>
        );
    }
}
