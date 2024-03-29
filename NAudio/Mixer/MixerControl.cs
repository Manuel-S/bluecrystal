// created on 10/12/2002 at 21:11
using System;
using System.Runtime.InteropServices;
using NAudio.Wave;

namespace NAudio.Mixer
{	
	/// <summary>
	/// Represents a mixer control
	/// </summary>
	public abstract class MixerControl 
	{
		internal MixerInterop.MIXERCONTROL mixerControl;
		internal MixerInterop.MIXERCONTROLDETAILS mixerControlDetails;
		/// <summary>
		/// Mixer ID
		/// </summary>
		protected int nMixer;
		/// <summary>
		/// Number of Channels
		/// </summary>
		protected int nChannels;
		
		/// <summary>
		/// Gets a specified Mixer Control
		/// </summary>
		/// <param name="nMixer">Mixer ID</param>
		/// <param name="nLineID">Line ID</param>
		/// <param name="nControl">Control ID</param>
		/// <param name="nChannels">Number of Channels</param>
		/// <returns></returns>
		public static MixerControl GetMixerControl(int nMixer, int nLineID, int nControl, int nChannels) 
		{
			MixerInterop.MIXERLINECONTROLS mlc = new MixerInterop.MIXERLINECONTROLS();
			MixerInterop.MIXERCONTROL mc = new MixerInterop.MIXERCONTROL();
			
			// set up the pointer to a structure
			IntPtr pMixerControl = Marshal.AllocCoTaskMem(Marshal.SizeOf(mc));
			Marshal.StructureToPtr(mc, pMixerControl, false);      
			
			mlc.cbStruct = Marshal.SizeOf(mlc);
			mlc.cControls = 1;
			mlc.dwControlID = nControl;
			mlc.cbmxctrl = Marshal.SizeOf(mc);
			mlc.pamxctrl = pMixerControl;
			mlc.dwLineID = nLineID;
            MmResult err = MixerInterop.mixerGetLineControls(nMixer, ref mlc, MixerFlags.OneById | MixerFlags.Mixer);
			if(err != MmResult.NoError) {
				Marshal.FreeCoTaskMem(pMixerControl);
				throw new MmException(err,"mixerGetLineControls");
			}
			
			// retrieve the structure from the pointer
			mc = (MixerInterop.MIXERCONTROL) Marshal.PtrToStructure(mlc.pamxctrl, typeof(MixerInterop.MIXERCONTROL));
			Marshal.FreeCoTaskMem(pMixerControl);
			
			if(MixerControl.IsControlBoolean(mc.dwControlType)) 
			{
				return new BooleanMixerControl(mc,nMixer,nChannels);
			}
			else if(MixerControl.IsControlSigned(mc.dwControlType)) 
			{
				return new SignedMixerControl(mc,nMixer,nChannels);
			}
			else if(MixerControl.IsControlUnsigned(mc.dwControlType)) 
			{
				return new UnsignedMixerControl(mc,nMixer,nChannels);
			}
			else if(MixerControl.IsControlListText(mc.dwControlType)) 
			{
				return new ListTextMixerControl(mc,nMixer,nChannels);
			}
			else if(MixerControl.IsControlCustom(mc.dwControlType)) 
			{
				return new CustomMixerControl(mc,nMixer,nChannels);
			}
			else 
			{
				throw new ApplicationException(String.Format("Unknown mixer control type {0}",mc.dwControlType));
			}
			
			
		}
		
		/// <summary>
		/// Gets the control details
		/// </summary>
		protected void GetControlDetails() 
		{
			mixerControlDetails.cbStruct = Marshal.SizeOf(mixerControlDetails);
			mixerControlDetails.dwControlID = mixerControl.dwControlID;
			if(IsCustom) 
			{
				mixerControlDetails.cChannels = 0;
			}
			else if((mixerControl.fdwControl & MixerInterop.MIXERCONTROL_CONTROLF_UNIFORM) != 0) 
			{
				mixerControlDetails.cChannels = 1;
			}
			else 
			{
				mixerControlDetails.cChannels = nChannels;
			}
			
			
			if((mixerControl.fdwControl & MixerInterop.MIXERCONTROL_CONTROLF_MULTIPLE) != 0) 
			{
				mixerControlDetails.cMultipleItems = mixerControl.cMultipleItems;
			}
			else if(IsCustom) 
			{
				mixerControlDetails.cMultipleItems = 0; // TODO: special cases
			}
			else 
			{
				mixerControlDetails.cMultipleItems = 0;
			}
			
			if(IsBoolean) 
			{
				mixerControlDetails.cbDetails = Marshal.SizeOf(new MixerInterop.MIXERCONTROLDETAILS_BOOLEAN());
			}
			else if(IsListText) 
			{
				mixerControlDetails.cbDetails = Marshal.SizeOf(new MixerInterop.MIXERCONTROLDETAILS_LISTTEXT());
			}
			else if(IsSigned) 
			{
				mixerControlDetails.cbDetails = Marshal.SizeOf(new MixerInterop.MIXERCONTROLDETAILS_SIGNED());
			}
			else if(IsUnsigned) 
			{
				mixerControlDetails.cbDetails = Marshal.SizeOf(new MixerInterop.MIXERCONTROLDETAILS_UNSIGNED());
			}
			else 
			{ // must be custom
				mixerControlDetails.cbDetails = mixerControl.Metrics.customData;
			}
			// from the structs sample in MSDN (see MyPerson2)
			IntPtr buffer = Marshal.AllocCoTaskMem(mixerControlDetails.cbDetails * mixerControlDetails.cChannels);
      		// To copy stuff in:
      		// Marshal.StructureToPtr( theStruct, buffer, false );
			mixerControlDetails.paDetails = buffer;
            MmResult err = MixerInterop.mixerGetControlDetails(nMixer, ref mixerControlDetails, MixerFlags.Value | MixerFlags.Mixer);
			// let the derived classes get the details before we free the handle			
			if(err == MmResult.NoError) 
			{
				GetDetails(mixerControlDetails.paDetails);
			}
		    Marshal.FreeCoTaskMem(buffer);
			if(err != MmResult.NoError) 
			{
				throw new MmException(err,"mixerGetControlDetails");
			}
		}

		/// <summary>
		/// Gets the control details
		/// </summary>
		/// <param name="pDetails"></param>
		protected abstract void GetDetails(IntPtr pDetails);

		/// <summary>
		/// Mixer control name
		/// </summary>
		public String Name 
		{
			get 
			{
				return mixerControl.szName;
			}
		}
		
		/// <summary>
		/// Mixer control type
		/// </summary>
		public MixerControlType ControlType 
		{
			get 
			{
				return mixerControl.dwControlType;
			}
		}
		
		/// <summary>
		/// Returns true if this is a boolean control
		/// </summary>
		/// <param name="controlType">Control type</param>
		private static bool IsControlBoolean(MixerControlType controlType) 
		{
			switch(controlType) 
			{
			case MixerControlType.BooleanMeter:
			case MixerControlType.Boolean:
			case MixerControlType.Button:
			case MixerControlType.Loudness:
			case MixerControlType.Mono:
			case MixerControlType.Mute:
			case MixerControlType.OnOff:
			case MixerControlType.StereoEnhance:
			case MixerControlType.Mixer:
			case MixerControlType.MultipleSelect:
			case MixerControlType.Mux:
			case MixerControlType.SingleSelect:
				return true;
			default:
				return false;
			}
		}
		
		/// <summary>
		/// Is this a boolean control
		/// </summary>
		public bool IsBoolean 
		{
			get 
			{
				return MixerControl.IsControlBoolean(mixerControl.dwControlType);
			}
		}
		
		/// <summary>
		/// Determines whether a specified mixer control type is a list text control
		/// </summary>
		private static bool IsControlListText(MixerControlType controlType) 
		{
			switch(controlType) 
			{
			case MixerControlType.Equalizer:
			case MixerControlType.Mixer:
			case MixerControlType.MultipleSelect:
			case MixerControlType.Mux:
			case MixerControlType.SingleSelect:
				return true;
			default:
				return false;
			}
		}
		
		/// <summary>
		/// True if this is a list text control
		/// </summary>
		public bool IsListText 
		{
			get 
			{
				return MixerControl.IsControlListText(mixerControl.dwControlType);
			}
		}
		
		private static bool IsControlSigned(MixerControlType controlType) 
		{
			switch(controlType) 
			{
			case MixerControlType.PeakMeter:
			case MixerControlType.SignedMeter:
			case MixerControlType.Signed:
			case MixerControlType.Decibels:
			case MixerControlType.Pan:
			case MixerControlType.QSoundPan:
			case MixerControlType.Slider:
				return true;
			default:
				return false;
			}
		}
		
		/// <summary>
		/// True if this is a signed control
		/// </summary>
		public bool IsSigned 
		{
			get 
			{
				return MixerControl.IsControlSigned(mixerControl.dwControlType);
			}
		}
		
		private static bool IsControlUnsigned(MixerControlType controlType) 
		{
			switch(controlType) 
			{
			case MixerControlType.UnsignedMeter:
			case MixerControlType.Unsigned:
			case MixerControlType.Bass:
			case MixerControlType.Equalizer:
			case MixerControlType.Fader:
			case MixerControlType.Treble:
			case MixerControlType.Volume:
			case MixerControlType.MicroTime:
			case MixerControlType.MilliTime:
			case MixerControlType.Percent:
				return true;
			default:
				return false;
			}
		}

		/// <summary>
		/// True if this is an unsigned control
		/// </summary>
		public bool IsUnsigned 
		{
			get 
			{
				return MixerControl.IsControlUnsigned(mixerControl.dwControlType);
			}
		}

		private static bool IsControlCustom(MixerControlType controlType) 
		{
			return (controlType == MixerControlType.Custom);
		}
		
		/// <summary>
		/// True if this is a custom control
		/// </summary>
		public bool IsCustom 
		{
			get 
			{
				return MixerControl.IsControlCustom(mixerControl.dwControlType);
			}
		}
		

	}
}
