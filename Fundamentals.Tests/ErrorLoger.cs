﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals.Tests
{
    public class ErrorLoger
    {
        public string LastError { get; set; }
        public event EventHandler<Guid> ErrorLogged;

        public void Log(string error)
        {
            if (string.IsNullOrWhiteSpace(error))
            {
                throw new ArgumentNullException();
            }
            LastError = error;
            // log the error to storage;

            ErrorLogged.Invoke(this, Guid.NewGuid());
        }
    }
}
