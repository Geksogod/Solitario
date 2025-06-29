namespace Appodeal.Core.CardAction
{
    public interface ICardAction<T> where T : ICardActionData
    {
        public T Data { get; set; }
        
        public void Precess();
        public void Undo();
    }
}