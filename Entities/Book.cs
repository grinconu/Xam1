﻿namespace Entities {     using System;     using Newtonsoft.Json;     using SQLite;      /// <summary>     /// Book.     /// </summary>     [Table("Book")]     public class Book     {         /// <summary>         /// Gets or sets the identifier sql.         /// </summary>         /// <value>The identifier sql.</value>         [PrimaryKey, AutoIncrement]         [JsonIgnore]         public int IdSql
        {             get;             set;         }          /// <summary>         /// Gets or sets the codigo.         /// </summary>         /// <value>The codigo.</value>         [JsonProperty("codigo")]         public int Codigo         {             get;             set;         }          /// <summary>         /// Gets or sets the name.         /// </summary>         /// <value>The name.</value>         [JsonProperty("name")]         public string Name         {             get;             set;         }          [JsonProperty("author")]         public string Author         {             get;             set;         }          [JsonProperty("year")]         public int Yaer         {             get;             set;         }          [JsonProperty("description")]         public string Description         {             get;             set;         }          [JsonProperty("language")]         public string Language         {             get;             set;         }          [JsonProperty("dateRecode")]         public DateTime DateRecord         {             get;             set;         }          [JsonProperty("_id")]         public string Id         {             get;             set;         }          public string Detalle
        {             get => $"Autor: {Author}, {Description}";         }      } } 