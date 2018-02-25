using System;
using SQLite.Net.Attributes;

namespace KaraokeTOP.Models
{
    [Table("Item")]
    public class Item
    {
        [PrimaryKey, Column("Id")]
        public string Id { get; set; }
        [Column("SongName")]
        public string SongName { get; set; }
        [Column("Artist")]
        public string Artist { get; set; }
        [Column("Lyrics")]
        public string Lyrics { get; set; }
        [Column("Language")]
        public string Language { get; set; }
        public string IdAndSongName
        {
            get
            {
                return string.Format("{0} - {1}", Id, SongName);
            }
        }
    }
}
