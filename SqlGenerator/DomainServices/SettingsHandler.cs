﻿using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using SqlGenerator.Entities;


namespace SqlGenerator.DomainServices
{
	public static class SettingsHandler
	{
		private static readonly string FileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.Settings.xml";
		private static readonly XmlSerializer Serializer = new XmlSerializer(typeof(Settings));

		public static Settings Get()
		{
			if (!File.Exists(FileName))
			{
				return new Settings();
			}
			using (var file = new StreamReader(FileName))
			{
				return (Settings)Serializer.Deserialize(file);
			}
		}

		public static void Save(Settings settings)
		{
			using (var file = new StreamWriter(FileName))
			{
				Serializer.Serialize(file, settings);
				file.Close();
			}
		}
	}
}