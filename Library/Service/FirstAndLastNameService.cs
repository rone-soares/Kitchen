using Library.Entities;

namespace Library.Service
{
    public class FirstAndLastNameService
    {
		public FirstAndLastName FirstAndLastName(string fullname)
		{
			var firstAndLast = new FirstAndLastName();

			var split = fullname.Split(new char[] { ' ' }, 2);

			if (split.Length == 1)
			{
				firstAndLast.FirstName = "";
				firstAndLast.LastName = split[0];
			}
			else
			{
				firstAndLast.FirstName = split[0];
				firstAndLast.LastName = split[1];
			}

			return firstAndLast;
		}
	}
}
