// created on 13/12/2002 at 22:01
using System;
using System.Runtime.InteropServices;
using NAudio.Wave;

namespace NAudio.Mixer 
{
	/// <summary>
	/// Represents a signed mixer control
	/// </summary>
	public class SignedMixerControl : MixerControl 
	{
		private MixerInterop.MIXERCONTROLDETAILS_SIGNED signedDetails;
	
		internal SignedMixerControl(MixerInterop.MIXERCONTROL mixerControl,int nMixer,int nChannels) 
		{
			this.mixerControl = mixerControl;
			this.nMixer = nMixer;
			this.nChannels = nChannels;
			this.mixerControlDetails = new MixerInterop.MIXERCONTROLDETAILS();
			GetControlDetails();
		}
		
		/// <summary>
		/// Gets details for this contrl
		/// </summary>
		protected override void GetDetails(IntPtr pDetails) 
		{
			signedDetails = (MixerInterop.MIXERCONTROLDETAILS_SIGNED) Marshal.PtrToStructure(mixerControlDetails.paDetails,typeof(MixerInterop.MIXERCONTROLDETAILS_SIGNED));
		}
		
		/// <summary>
		/// The value of the control
		/// </summary>
		public int Value 
		{
			get 
			{
				GetControlDetails();				
				return signedDetails.lValue;
			}
			set 
			{
				//GetControlDetails();
				signedDetails.lValue = value;
				// TODO: pin memory
                MmException.Try(MixerInterop.mixerSetControlDetails(nMixer, ref mixerControlDetails, MixerFlags.Value | MixerFlags.MixerHandle), "mixerSetControlDetails");
			}
		}
		
		/// <summary>
		/// Minimum value for this control
		/// </summary>
		public int MinValue 
		{
			get 
			{
				return mixerControl.Bounds.minimum;
			}
		}

		/// <summary>
		/// Maximum value for this control
		/// </summary>
		public int MaxValue 
		{
			get 
			{
				return mixerControl.Bounds.maximum;
			}
		}				
	}
}
