using System;
namespace WinTail
{
    public class Messages
    {
        #region Neutral/system messages
        /// <summary>
        /// Marker class to continue processing.
        /// </summary>
        public class ContinueProcessing
        {

        }
        #endregion

        #region Success messages
        /// <summary>
        /// Base class to signal valid user input. 
        /// </summary>
        public class InputSuccess
        {
            public string Reason { get; private set; }
            public InputSuccess(string reason)
            {
                Reason = reason;
            }
        }
        #endregion

        #region Error messages
        /// <summary>
        /// Base class to signal invalid user input. 
        /// </summary>
        public class InputError
        {
            public string Reason { get; private set; }
            public InputError(string reason)
            {
                Reason = reason;
            }
        }

        /// <summary>
        /// User provided blank input.
        /// </summary>
        public class NullInputError : InputError
        {
            public NullInputError(string reason) : base(reason) { }
        }

        /// <summary>
        /// User provided invalid input (currently, input w/ odd # chars)
        /// </summary>
        public class ValidationError : InputError
        {
            public ValidationError(string reason) : base(reason) { }
        }
        #endregion
    }
}
