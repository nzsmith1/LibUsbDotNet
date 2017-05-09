using System;
using System.Collections.Generic;
using System.Text;
using LibUsbDotNet.Info;
using MonoLibUsb.Descriptors;
using LibUsbDotNet.LudnMonoLibUsb;

namespace LibUsbDotNet.MonoLibUsb
{
    internal class MonoUsbConfigInfo: UsbConfigInfo
    {
        internal MonoUsbConfigInfo(MonoUsbDevice usbDevice, MonoUsbConfigDescriptor configDescriptor):base(usbDevice, configDescriptor)
        {
            //mUsbConfigDescriptor = new UsbConfigDescriptor(configDescriptor);

            List<MonoUsbInterface> monoUSBInterfaces = configDescriptor.InterfaceList;
            foreach (MonoUsbInterface usbInterface in monoUSBInterfaces)
            {
                List<MonoUsbAltInterfaceDescriptor> monoUSBAltInterfaces = usbInterface.AltInterfaceList;
                foreach (MonoUsbAltInterfaceDescriptor monoUSBAltInterface in monoUSBAltInterfaces)
                {
                    UsbInterfaceInfo usbInterfaceInfo = new UsbInterfaceInfo(mUsbDevice, monoUSBAltInterface);
                    mInterfaceList.Add(usbInterfaceInfo);
                }
            }
        }
    }
}
