using System.Collections.Generic;
using Model;
// <copyright file="SupplierControllerTest.cs">Copyright ©  2015</copyright>

using System;
using BusinessLogic;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic.Tests
{
    [TestClass]
    [PexClass(typeof(SupplierController))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class SupplierControllerTest
    {

        [PexMethod(MaxBranches = 20000)]
        public List<Supplier> getSupplierList([PexAssumeUnderTest]SupplierController target)
        {
            List<Supplier> result = target.getSupplierList();
            return result;
            // TODO: add assertions to method SupplierControllerTest.getSupplierList(SupplierController)
        }
    }
}
