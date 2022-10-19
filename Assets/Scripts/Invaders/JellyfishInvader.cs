namespace Invaders
{
    public class JellyfishInvader : Invader
    {
        public override void ReceiveDamage()
        {
            Score.AddScore(20);
        }
    }
}