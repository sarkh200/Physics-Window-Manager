namespace Physics_Window_Manager.WindowManagement.Physics
{
	internal class Calculate
	{
		public static void CalculateWindowPosition((int x, int y) position, (int x, int y) velocity, out (int x, int y) outPos) =>
			outPos = (position.x + velocity.x, position.y + velocity.y);

		public static void CalculateVelocity((int x, int y) displacement, int time, out (int x, int y) outDisplacement)
		{
			if (time != 0)
			{
				outDisplacement = (displacement.x / time, displacement.y / time);
			}
			else
			{
				outDisplacement = (0, 0);
			}
		}

		public static void CalculateCollisions((int x, int y) position, (int x, int y) velocity, (int width, int height) windowDims, (int width, int height) screenDims, ProcessData.RECT borders, int elasticity, out (int x, int y) outPos, out (int x, int y) outVelocity, out bool isGrounded)
		{
			if (position.x < -borders.Left)
			{
				outPos.x = -borders.Left + 1;
				outVelocity.x = Math.Abs(velocity.x / elasticity);
			}
			else if (position.x + windowDims.width > screenDims.width + borders.Right)
			{
				outPos.x = screenDims.width - windowDims.width + borders.Right;
				outVelocity.x = Math.Abs(velocity.x / elasticity) * -1;
			}
			else
			{
				outPos.x = position.x;
				outVelocity.x = velocity.x;
			}

			if (position.y < -borders.Top)
			{
				isGrounded = false;
				outPos.y = -borders.Top + 1;
				outVelocity.y = Math.Abs(velocity.y / elasticity);
			}
			else if (position.y + windowDims.height > screenDims.height + borders.Bottom)
			{
				isGrounded = true;
				outPos.y = screenDims.height - windowDims.height + borders.Bottom;
				outVelocity.y = Math.Abs(velocity.y / elasticity) * -1;
			}
			else
			{
				isGrounded = false;
				outPos.y = position.y;
				outVelocity.y = velocity.y;
			}
		}

		public static bool IsPointWithinRect(Point point, ProcessData.RECT rect)
		{
			return point.X >= rect.Left && point.X <= rect.Right && point.Y >= rect.Top && point.Y <= rect.Bottom;
		}
	}
}
