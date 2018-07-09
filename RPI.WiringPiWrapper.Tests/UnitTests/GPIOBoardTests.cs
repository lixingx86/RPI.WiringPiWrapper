﻿using RPI.WiringPiWrapper.Hardware.GPIOBoard;
using System;
using AutoFixture;
using RPI.WiringPiWrapper.Tools.Loggers;
using RPI.WiringPiWrapper.WiringPi.Wrappers.Init;
using Xunit;

namespace RPI.WiringPiWrapper.Tests.UnitTests
{
    public class GPIOBoardTests
    {
        [Fact]
        [Trait("Category", "UnitTests")]
        public void When_Constructor_IsCalled_With_Null_Patameter_Then_ExceptionIsThrown()
        {
            //a
            Action create = () => new GPIOBoard(null, null);

            //aa

            //aaa
            Assert.Throws<ArgumentNullException>(create);
        }

        [Fact]
        [Trait("Category", "UnitTests")]
        public void When_Constructor_IsCalled_With_Any_Patameter_Then_InstanceIsCreated()
        {
            //a
            var fixture = new Fixture();
            //fixture.Customize(new AutoConfiguredMoqCustomization());

            var loggerStub = new DummyLogger();
            var initStub = fixture.Create<IWrapInit>();
            void callToCtor() => new GPIOBoard(loggerStub, null);

            //aa

            //aaa
            callToCtor();
        }
    }
}