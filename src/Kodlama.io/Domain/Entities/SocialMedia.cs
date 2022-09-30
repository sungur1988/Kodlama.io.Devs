using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SocialMedia :Entity
    {
        public string Name { get; set; }
        public string UrlAddress { get; set; }
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public SocialMedia()
        {

        }
        public SocialMedia(int id,string name,string urlAddress,int appUserId):this()
        {
            Id = id;
            Name = name;
            UrlAddress = urlAddress;
            AppUserId = appUserId;
        }
    }
}
