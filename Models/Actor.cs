using System;
using System.Collections.Generic;

#nullable disable

namespace MyStudioApp.Models
{
    public partial class Actor
    {
        public Actor()
        {
            SceneActors = new HashSet<SceneActor>();
        }

        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int? Phone { get; set; }
        public string Email { get; set; }

        public virtual Account UsernameNavigation { get; set; }
        public virtual ICollection<SceneActor> SceneActors { get; set; }
    }
}
