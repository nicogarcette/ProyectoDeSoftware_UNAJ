using NgCinema.Application.Exceptions;
using System.Globalization;

namespace NgCinema.Application.Validators
{
    public static class ValidData
    {
        public static TimeSpan ValidTime(string time)
        {
            TimeSpan value;
            TimeSpan open = new TimeSpan(12, 0, 0);
            TimeSpan close = new TimeSpan(23, 0, 0);
            try
            {
                value = TimeSpan.ParseExact(time,"hh\\:mm", CultureInfo.InvariantCulture);

                if(!(open <= value && value <= close))
                    throw new BussinesException();
            }
            catch(Exception)
            {
                throw new BussinesException("El formato debe ser hh:mm y rango horario permitido horario 12:00 a 23:00");
            }

            return value;
        }
    }
}
