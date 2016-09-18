namespace LockerRiddle
{
	public class Locker
	{
		public bool Open { get; set; }

		public uint TimesOpened { get; set; }
		public uint TimesClosed { get; set; }
		public double PercentOpen => (double)TimesOpened / (double)(TimesOpened + TimesClosed) * 100.0;

		public string GetState()
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
			return $"State: {GetState()}\tTimesOpened: {TimesOpened}\tTimesClosed: {TimesClosed}\tPercentOpen: {PercentOpen}%";
		}
	}
}