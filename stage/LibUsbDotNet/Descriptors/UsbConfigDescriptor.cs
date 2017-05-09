// Copyright � 2006-2010 Travis Robinson. All rights reserved.
// 
// website: http://sourceforge.net/projects/libusbdotnet
// e-mail:  libusbdotnet@gmail.com
// 
// This program is free software; you can redistribute it and/or modify it
// under the terms of the GNU General Public License as published by the
// Free Software Foundation; either version 2 of the License, or 
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but 
// WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
// or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License
// for more details.
// 
// You should have received a copy of the GNU General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA. or 
// visit www.gnu.org.
// 
// 
using System;
using System.Runtime.InteropServices;
using LibUsbDotNet.Main;

#pragma warning disable 649

namespace LibUsbDotNet.Descriptors
{
    /// <summary> Usb Configuration Descriptor.
    /// </summary> 
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class UsbConfigDescriptor : UsbDescriptor
    {
        /// <summary>
        /// Total size of this structure in bytes.
        /// </summary>
        public new static readonly int Size = Marshal.SizeOf<UsbConfigDescriptor>();

        /// <summary>
        /// Total length in bytes of data returned
        /// </summary>
        public short TotalLength { get; protected set; }

        /// <summary>
        /// Number of Interfaces
        /// </summary>
        public byte InterfaceCount { get; protected set; }

        /// <summary>
        /// Value to use as an argument to select this Configuration
        /// </summary>
        public byte ConfigID { get; protected set; }

        /// <summary>
        /// Index of String Descriptor describing this Configuration
        /// </summary>
        public byte StringIndex { get; protected set; }

        /// <summary>
        /// D7 Reserved, set to 1. (USB 1.0 Bus Powered)
        /// D6 Self Powered
        /// D5 Remote Wakeup
        /// D4..0 Reserved, set to 0.
        /// </summary>
        public byte Attributes { get; protected set; }

        /// <summary>
        /// Maximum Power Consumption in 2mA units 
        /// </summary>
        public byte MaxPower { get; protected set; }

        internal UsbConfigDescriptor() { }

        ///<summary>
        ///Returns a <see cref="T:System.String"/> that represents the current <see cref="UsbConfigDescriptor"/>.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="System.String"/> that represents the current <see cref="UsbConfigDescriptor"/>.
        ///</returns>
        public override string ToString() { return ToString("", ToStringParamValueSeperator, ToStringFieldSeperator); }

        ///<summary>
        ///Returns a <see cref="T:System.String"/> that represents the current <see cref="UsbConfigDescriptor"/>.
        ///</summary>
        ///
        ///<param name="prefixSeperator">The field prefix string.</param>
        ///<param name="entitySperator">The field/value seperator string.</param>
        ///<param name="suffixSeperator">The value suffix string.</param>
        ///<returns>A formatted representation of the <see cref="UsbConfigDescriptor"/>.</returns>
        public string ToString(string prefixSeperator, string entitySperator, string suffixSeperator)
        {
            Object[] values = {Length, DescriptorType, TotalLength, InterfaceCount, ConfigID, StringIndex, "0x" + Attributes.ToString("X2"), MaxPower};
            string[] names = {"Length", "DescriptorType", "TotalLength", "InterfaceCount", "ConfigID", "StringIndex", "Attributes", "MaxPower"};

            return Helper.ToString(prefixSeperator, names, entitySperator, values, suffixSeperator);
        }
    }
}