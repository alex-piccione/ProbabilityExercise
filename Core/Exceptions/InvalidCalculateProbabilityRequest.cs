﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Probability.Core.Exceptions
{
    public class InvalidCalculateProbabilityRequest : Exception
    {
        public string[] Errors { get; set; }

        public InvalidCalculateProbabilityRequest(string[] errors) {
            Errors = errors;
        }
    }
}
