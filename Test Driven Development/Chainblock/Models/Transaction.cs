﻿using System;
using Chainblock.Common;
using Chainblock.Contracts;

namespace Chainblock.Models
{
    public class Transaction : ITransaction
    {
        private const int MIN_ID_VALUE = 0;

        private int id;
        private string from;
        private string to;
        private double amount;

        public Transaction(int id, TransactionStatus transactionStatus, string to, string from, double amount)
        {
            this.Id = id;
            this.Status = transactionStatus;
            this.From = from;
            this.To = to;
            this.Amount = amount;
        }

        public int Id
        {
            get => this.id;
            set
            {
                if (value <= MIN_ID_VALUE)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidIdMessage);
                }

                this.id = value;
            }
        }

        public TransactionStatus Status { get; set; }

        public string From
        {
            get => this.from;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidSenderUsernameMessage);
                }

                this.from = value;
            }
        }

        public string To {
            get => this.to;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidReceiverUsernameMessage);
                }

                this.to = value;
            }
        }

        public double Amount
        {
            get => this.amount;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAmountMessage);
                }

                this.amount = value;
            }
        }
    }
}
