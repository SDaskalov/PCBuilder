﻿namespace PCBuilder.Common
{
	public static class ValidationConstants
	{
		public static class Socket
		{
			public const int NameMaxLength = 50;
		}
		public static class CpuConstants
		{
			public const int MaxNameLength = 50;
			public const int MaxPrice = 10000;
			public const int MinPrice = 1;
            public const int MinWatts = 1;
            public const int MaxWatts = 1000;
        }
		public static class CaseConstants
		{
			public const int MaxNameLength = 50;
			public const int MaxPrice = 10000;
			public const int MinPrice = 1;
			public const int MaxCaseImageLength = 2048;
		}
		public static class MotherBoardConstants
		{
			public const int MaxNameLength = 50;
			public const int MaxPrice = 10000;
			public const int MinPrice = 1;

			
		}
		public static class BuilderConstants
		{
			public const int MaxNameLength = 50;
            public const int MinNameLength = 4;

        }


	}
}
