namespace Invaders
{
    public class CrabInvader : Invader
    {
        public override void ReceiveDamage()
        {
            Score.AddScore(10);
        }
    }
}