using System;
using System.Collections.Generic;
using System.Text;

namespace Shoes_Store.Ultility.Common
{
    public class ShoerserException
    {
        public class AccountException
        {
            public const string A01 = "Username not found";
            public const string A02 = "This account is not existed";
            public const string A03 = "Username can not be blank";
            public const string A04 = "Fullname can not be blank";
            public const string A05 = "This User is already exist";
            public const string A06 = "User role must be Admin(0), Moderator(1) or Customer(2)";
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
            public const string O02 = "no item in cart";
        }
        public class HistpryException
        {
            public const string H01 = "This history is not existed";
        }
        public class OrderDetailException
        {
            public const string OD01 = "Quantity must be > 0";
            public const string OD02 = "Quantity must not large than current Quantity Of Product";
        }
    }
}
