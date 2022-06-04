using System.Runtime.Serialization;

namespace Common.Infrastucture.DataAccess.Exception
{
    /// <summary>
    /// Исключение, выбрасываемое, если сущность не была найдена.
    /// </summary>
    [Serializable]
    public class EntityNotFoundException : System.Exception
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="EntityNotFoundException"/>.
        /// </summary>
        public EntityNotFoundException()
        {
        }

        /// <summary>
        /// Инициализирует экземпляр <see cref="EntityNotFoundException"/>.
        /// </summary>
        protected EntityNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Инициализирует экземпляр <see cref="EntityNotFoundException"/>.
        /// </summary>
        public EntityNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Инициализирует экземпляр <see cref="EntityNotFoundException"/>.
        /// </summary>
        public EntityNotFoundException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}