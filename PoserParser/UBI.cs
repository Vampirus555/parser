namespace PoserParser
{
	public class UBIFull
	{
        public string ID { get; }
        public string Name { get; }
        public string Description { get; }
        public string HazardSource { get; }
        public string HazardObject { get; }
        public string ConfidentialCheck { get; }
        public string IntegrityCheck { get; }
        public string AccessibiltiyCheck { get; }

		public UBIFull(string iD, string name, string description, string hazardSource, string hazardObject, string confidentialCheck, string integrityCheck, string accessibiltiyCheck)
		{
			ID = iD;
			Name = name;
			Description = description;
			HazardSource = hazardSource;
			HazardObject = hazardObject;
			ConfidentialCheck = confidentialCheck;
			IntegrityCheck = integrityCheck;
			AccessibiltiyCheck = accessibiltiyCheck;
        }

        public bool Equals(UBIFull db)
        {
            return ID == db.ID && Name == db.Name && Description == db.Description
                && HazardSource == db.HazardSource && HazardObject == db.HazardObject
                && ConfidentialCheck == db.ConfidentialCheck
                && IntegrityCheck == db.IntegrityCheck
                && AccessibiltiyCheck == db.AccessibiltiyCheck;
        }
    }


    public class UBIShort
    {
        public string ID { get; }
        public string Name { get; }

        public UBIShort(string iD, string name)
        {
            ID = iD;
            Name = name;
        }

    }
}