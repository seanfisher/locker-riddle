namespace LockerRiddle
{
	public class Locker
	{
		public bool Open { get; set; }

		public uint TimesOpened { get; set; }
		public uint TimesClosed { get; set; }
		public double PercentOpen => (double)TimesOpened / (double)(TimesOpened + TimesClosed);

		public string GetDisplayState()
		{
			return Open ? "Open" : "Closed";
		}

		public void Toggle()
		{
			if (Open)
			{
				TimesClosed++;
			}
			else
			{
				TimesOpened++;
			}

			Open = !Open;
		}

		public override string ToString()
		{
			return string.Format("State: {0}\tTimes Opened: {1}\tTimes Closed: {2}\tPercent Open: {3:P2}", 
				GetDisplayState(), TimesOpened, TimesClosed, double.IsNaN(PercentOpen) ? 0 : PercentOpen);
		}
	}
}