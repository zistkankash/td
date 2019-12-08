using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
	public class TriggerEvents
	{
		public int condition;
		public int trialStart;
		public int trialEnd;
		public int fixOn;
		public int fixOff;
		public int stimOn;
		public int stimOff;
		public int enterFixWindow;
		public int abortFixWindow;
		public int enterTargetWindow;
		public int saccadInit;
		public int saccadLand;
		
		public TriggerEvents(params int[] events)
		{
			if (events.Length == 0)
				ClearEvents();
			if (events.Length >= 1)
				condition = events[0];
			if (events.Length >= 2)
				trialStart = events[1];
			if (events.Length >= 3)
				trialEnd = events[2];
			if (events.Length >= 4)
				fixOn = events[3];
			if (events.Length >= 5)
				fixOff = events[4];
			if (events.Length >= 6)
				stimOn = events[5];
			if (events.Length >= 7)
				stimOff = events[6];
			if (events.Length >= 8)
				enterFixWindow = events[7];
			if (events.Length >= 9)
				abortFixWindow = events[8];
			if (events.Length >= 10)
				enterTargetWindow = events[9];
			if (events.Length >= 11)
				saccadInit = events[10];
			if (events.Length >= 12)
				saccadLand = events[11];
		}

		public TriggerEvents()
		{
			ClearEvents();
		}

		public void ClearEvents()
		{
			condition = -1; trialStart = -1; trialEnd = -1; fixOn = -1; fixOff = -1; stimOn = -1; stimOff = -1;
			enterFixWindow = -1; abortFixWindow = -1; enterTargetWindow = -1; saccadInit = -1; saccadLand = -1;
		}

		public bool SetEvent(int EvId, int Value)
		{
			if (EvId > 12 || EvId < 1)
				return false;
			if (Value == 0)
				Value = -1;
			if (EvId == 1)
				condition = Value;
			if (EvId == 2)
				trialStart = Value;
			if (EvId == 3)
				trialEnd = Value;
			if (EvId == 4)
				fixOn = Value;
			if (EvId == 5)
				fixOff = Value;
			if (EvId == 6)
				stimOn = Value;
			if (EvId == 7)
				stimOff = Value;
			if (EvId == 8)
				enterFixWindow = Value;
			if (EvId == 9)
				abortFixWindow = Value;
			if (EvId == 10)
				enterTargetWindow = Value;
			if (EvId == 11)
				saccadInit = Value;
			if (EvId == 12)
				saccadLand = Value;
			return true;
		}

		public int GetEvent(int EvId)
		{
			
			if (EvId == 1)
				 return condition;
			if (EvId == 2)
				return trialStart;
			if (EvId == 3)
				return trialEnd;
			if (EvId == 4)
				return fixOn;
			if (EvId == 5)
				return fixOff;
			if (EvId == 6)
				return stimOn;
			if (EvId == 7)
				return stimOff;
			if (EvId == 8)
				return enterFixWindow;
			if (EvId == 9)
				return abortFixWindow;
			if (EvId == 10)
				return enterTargetWindow;
			if (EvId == 11)
				return saccadInit;
			if (EvId == 12)
				return saccadLand;
			return -1;
		}

		public TriggerEvents NewInstant()
		{
			return  new TriggerEvents(condition,trialStart,trialEnd,fixOn,fixOff,stimOn,stimOff,enterFixWindow,abortFixWindow,enterTargetWindow,saccadInit,saccadLand);
		}
	}
}
