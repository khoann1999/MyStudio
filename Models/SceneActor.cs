using System;
using System.Collections.Generic;

#nullable disable

namespace MyStudioApp.Models
{
    public partial class SceneActor
    {
        public int Id { get; set; }
        public int? SceneId { get; set; }
        public string ActorUsername { get; set; }

        public virtual Actor ActorUsernameNavigation { get; set; }
        public virtual Scene Scene { get; set; }
    }
}
