using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kafka.Client
{
    /// <summary>
    /// A wrapping of an error code returned from Kafka.
    /// </summary>
    public class KafkaException : Exception
    {
        /// <summary>
        /// No error occurred.
        /// </summary>
        public const int NoError = 0;

        /// <summary>
        /// The offset requested was out of range.
        /// </summary>
        public const int OffsetOutOfRangeCode = 1;

        /// <summary>
        /// The message was invalid.
        /// </summary>
        public const int InvalidMessageCode = 2;

        /// <summary>
        /// The wrong partition.
        /// </summary>
        public const int WrongPartitionCode = 3;

        /// <summary>
        /// Invalid message size.
        /// </summary>
        public const int InvalidRetchSizeCode = 4;

        /// <summary>
        /// Initializes a new instance of the KafkaException class.
        /// </summary>
        /// <param name="errorCode">The error code generated by a request to Kafka.</param>
        public KafkaException(int errorCode) : base(GetMessage(errorCode))
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Gets the error code that was sent from Kafka.
        /// </summary>
        public int ErrorCode { get; private set; }

        /// <summary>
        /// Gets the message for the exception based on the Kafka error code.
        /// </summary>
        /// <param name="errorCode">The error code from Kafka.</param>
        /// <returns>A string message representation </returns>
        private static string GetMessage(int errorCode)
        {
            if (errorCode == OffsetOutOfRangeCode)
            {
                return "Offset out of range";
            }
            else if (errorCode == InvalidMessageCode)
            {
                return "Invalid message";
            }
            else if (errorCode == WrongPartitionCode)
            {
                return "Wrong partition";
            }
            else if (errorCode == InvalidRetchSizeCode)
            {
                return "Invalid message size";
            }
            else
            {
                return "Unknown error";
            }
        }
    }
}
