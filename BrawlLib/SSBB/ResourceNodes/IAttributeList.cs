﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrawlLib.SSBB.ResourceNodes {
	public interface IAttributeList {
		/// <summary>
		/// Address of the first entry.
		/// </summary>
		VoidPtr Address { get; }
		/// <summary>
		/// The number of (four-byte) entries - i.e. the length in bytes divided by four.
		/// </summary>
		int NumEntries { get; }

		void SetFloat(int index, float value);
		float GetFloat(int index);
		void SetInt(int index, int value);
		int GetInt(int index);

		void SignalPropertyChange();
	}
}
