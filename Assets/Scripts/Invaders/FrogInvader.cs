namespace Invaders
{
    public class FrogInvader : Invader
    {
        public override void ReceiveDamage()
        {
            Score.AddScore(30);
        }
    }
}