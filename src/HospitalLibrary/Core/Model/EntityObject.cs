namespace HospitalLibrary.Core.Model
{
    public abstract class EntityObject
    {
        public int Id { get; set; }
        //protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            var entityObject = (EntityObject)obj;

            return Id == entityObject.Id;
        }

        public int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(EntityObject a, EntityObject b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(EntityObject a, EntityObject b)
        {
            return !(a == b);
        }
    }
}
