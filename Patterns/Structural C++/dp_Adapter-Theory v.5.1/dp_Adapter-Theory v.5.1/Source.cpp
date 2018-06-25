#include <iostream>
using namespace std;

class Rectangle
{
public:
	virtual void draw() = 0;
};

class LegacyRectangle
{
public:
	LegacyRectangle(int x1, int y1, int x2, int y2)
	{
		x1_ = x1;
		y1_ = y1;
		x2_ = x2;
		y2_ = y2;
		cout << "LegacyRectangle:  create.  (" << x1_ << "," << y1_ << ") => ("
			<< x2_ << "," << y2_ << ")" << endl;
	}
	void oldDraw()
	{
		cout << "LegacyRectangle:  oldDraw.  (" << x1_ << "," << y1_ <<
			") => (" << x2_ << "," << y2_ << ")" << endl;
	}
private:
	int x1_;
	int y1_;
	int x2_;
	int y2_;
};

class RectangleAdapter : public Rectangle, private LegacyRectangle
{
public:
	RectangleAdapter(int x, int y, int w, int h) :
		LegacyRectangle(x, y, x + w, y + h)
	{
		cout << "RectangleAdapter: create.  (" << x << "," << y <<
			"), width = " << w << ", height = " << h << endl;
	}
	virtual void draw()
	{
		cout << "RectangleAdapter: draw." << endl;
		oldDraw();
	}
};

int main()
{
	Rectangle *r = new RectangleAdapter(120, 200, 60, 40);
	r->draw();


	system("pause");
	return 0;
}

//Output:
//LegacyRectangle:  create.  (120, 200) = > (180, 240)
//RectangleAdapter: create.  (120, 200), width = 60, height = 40
//RectangleAdapter : draw.
//LegacyRectangle : oldDraw.  (120, 200) = > (180, 240)