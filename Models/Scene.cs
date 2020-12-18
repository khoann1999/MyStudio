using System;
using System.Collections.Generic;

#nullable disable

namespace MyStudioApp.Models
{
    public partial class Scene
    {
        public Scene()
        {
            SceneActors = new HashSet<SceneActor>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Script { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }

        public virtual ICollection<SceneActor> SceneActors { get; set; }
    }
}
