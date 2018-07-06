﻿using System;
using System.Collections.Generic;
using System.Linq;
using RPI.WiringPiWrapper.Hardware.GPIOBoard.Exceptions;
using RPI.WiringPiWrapper.Interfaces;
using RPI.WiringPiWrapper.WiringPi;

namespace RPI.WiringPiWrapper.Hardware.GPIOBoard
{
    public class GPIOBoard
    {
        private ILogger _log;

        public IList<IDevice> DevicesList => _devicesList;
        private IList<IDevice> _devicesList;

        public IList<IPin> PinsList => _pinsList;
        private IList<IPin> _pinsList;

        public GPIOBoard(ILogger log)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log));

            Initialize();
        }

        private void Initialize()
        {
            if (Init.WiringPiSetup() == -1)
            {
                throw new GPIOInitializationException();
            }

            _devicesList = new List<IDevice>();
            _pinsList = new List<IPin>();

            _log.WriteMessage("GPIO initialized");
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }

        public void AddDevice(IDevice device) => DevicesList.Add(device);

        public IDevice GetDevice(Func<IDevice, bool> searchFunc) => DevicesList.FirstOrDefault(searchFunc);
        public IEnumerable<IDevice> SearchDevices(Func<IDevice, bool> searchFunc) => DevicesList.Where(searchFunc);

        public IPin GetPin(Func<IPin, bool> searchFunc) => PinsList.FirstOrDefault(searchFunc);
        public IEnumerable<IPin> SearchPins(Func<IPin, bool> searchFunc) => PinsList.Where(searchFunc);
    }
}