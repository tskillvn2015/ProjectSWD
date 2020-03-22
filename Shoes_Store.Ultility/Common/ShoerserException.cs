﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shoes_Store.Ultility.Common
{
    public class ShoerserException
    {
        public class AccountException
        {
            public const string A01 = "Username not found";
        }
        public class ProductException
        {
            public const string P01 = "must be a positive number";
            public const string P02 = "Category length must not highger than 200";
            public const string P03 = "This product is not existed";
            public const string P04 = "List product is empty";
        }
        public class OrderException
        {
            public const string O01 = "must be > 0";
        }
        public class HistpryException
        {
            public const string H01 = "This history is not existed";
        }
    }
}
