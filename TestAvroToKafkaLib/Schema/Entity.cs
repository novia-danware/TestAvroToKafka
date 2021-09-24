﻿// ------------------------------------------------------------------------------
// <auto-generated>
//    Generated by avrogen, version 1.7.7.5
//    Changes to this file may cause incorrect behavior and will be lost if code
//    is regenerated
// </auto-generated>
// ------------------------------------------------------------------------------
namespace TestAvroToKafkaLib.Schema
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using global::Avro;
	using global::Avro.Specific;

	public partial class Entity : ISpecificRecord
	{
		public static Schema _SCHEMA = Schema.Parse(@"{""type"":""record"",""name"":""Entity"",""namespace"":""TestAvroToKafkaLib.Schema"",""fields"":[{""name"":""entity_id"",""type"":[""null"",""string""]},{""name"":""entity_type"",""type"":[""null"",""string""]},{""name"":""name"",""type"":[""null"",""string""]}]}");
		private string _entity_id;
		private string _entity_type;
		private string _name;
		public virtual Schema Schema
		{
			get
			{
				return Entity._SCHEMA;
			}
		}
		public string entity_id
		{
			get
			{
				return this._entity_id;
			}
			set
			{
				this._entity_id = value;
			}
		}
		public string entity_type
		{
			get
			{
				return this._entity_type;
			}
			set
			{
				this._entity_type = value;
			}
		}
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}
		public virtual object Get(int fieldPos)
		{
			switch (fieldPos)
			{
				case 0: return this.entity_id;
				case 1: return this.entity_type;
				case 2: return this.name;
				default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
			};
		}
		public virtual void Put(int fieldPos, object fieldValue)
		{
			switch (fieldPos)
			{
				case 0: this.entity_id = (System.String)fieldValue; break;
				case 1: this.entity_type = (System.String)fieldValue; break;
				case 2: this.name = (System.String)fieldValue; break;
				default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
			};
		}
	}
}