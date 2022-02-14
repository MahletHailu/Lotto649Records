using System;
using System.Diagnostics.CodeAnalysis;

namespace BusinessLogic.Models.Services
{
    /// <summary>
    /// Represents user selected numbers
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Selection
    {
        private int _number1;

        /// <summary>
        /// public setter and getter for user input for draw number 1
        /// Validation: number can't be less than 1 or greater than 49
        /// </summary>
        public int Number1
        {

            get
            {
                return this._number1;
            }

            set
            {
                if (value < 1 || value > 49)
                {
                    throw new ArgumentOutOfRangeException("Number has to be between 1 and 49");
                }

                _number1 = value;
            }
        }

        private int _number2;

        /// <summary>
        /// public setter and getter for user input for draw number 2
        /// Validation: number can't be less than 1 or greater than 49
        /// </summary>
        public int Number2
        {

            get
            {
                return this._number2;
            }

            set
            {
                if (value < 1 || value > 49)
                {
                    throw new ArgumentOutOfRangeException("Number has to be between 1 and 49");
                }

                _number2 = value;
            }
        }

        private int _number3;

        /// <summary>
        /// public setter and getter for user input for draw number 3
        /// Validation: number can't be less than 1 or greater than 49
        /// </summary>
        public int Number3
        {

            get
            {
                return this._number3;
            }

            set
            {
                if (value < 1 || value > 49)
                {
                    throw new ArgumentOutOfRangeException("Number has to be between 1 and 49");
                }

                _number3 = value;
            }
        }

        private int _number4;

        /// <summary>
        /// public setter and getter for user input for draw number 4
        /// Validation: number can't be less than 1 or greater than 49
        /// </summary>
        public int Number4
        {

            get
            {
                return this._number4;
            }

            set
            {
                if (value < 1 || value > 49)
                {
                    throw new ArgumentOutOfRangeException("Number has to be between 1 and 49");
                }

                _number4 = value;
            }
        }

        private int _number5;

        /// <summary>
        /// public setter and getter for user input for draw number 5
        /// Validation: number can't be less than 1 or greater than 49
        /// </summary>
        public int Number5
        {

            get
            {
                return this._number5;
            }

            set
            {
                if (value < 1 || value > 49)
                {
                    throw new ArgumentOutOfRangeException("Number has to be between 1 and 49");
                }

                _number5 = value;
            }
        }

        private int _number6;

        /// <summary>
        /// public setter and getter for user input for draw number 6
        /// Validation: number can't be less than 1 or greater than 49
        /// </summary>
        public int Number6
        {

            get
            {
                return this._number6;
            }

            set
            {
                if (value < 1 || value > 49)
                {
                    throw new ArgumentOutOfRangeException("Number has to be between 1 and 49");
                }

                _number6 = value;
            }
        }
    }
}
