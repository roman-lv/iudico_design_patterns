#include <iostream>
using namespace std;


class WindowImp { // Implementator - реалізація
				  // містить інтерфейс для класу Window
public:
	virtual void DevDrawLine() = 0;
	virtual void DevDrawText() = 0;
};


class XWindowImp : public WindowImp { // ConcreteImplementatroA
									  // конкретна реалізація під систему  XWindow
public:
	void DevDrawText() { cout << "Xtext" << endl; };
	void DevDrawLine() { cout << "Drawing Xline" << endl; }
};


class PMWindowImp : public WindowImp { // ConcreteImplementatroB
	// конкретна реалізація під систему  PMWindow
public:
	void DevDrawText() { cout << "PMtext" << endl; };
	void DevDrawLine() { cout << "Drawing PMWindow line..." << endl; }
};



class Window // Abstraction
			 // інтерфейс для користувача
{
public:
	void DrawText() { _imp->DevDrawText(); }
	void DrawRect() { _imp->DevDrawLine(); }
	Window& operator=(WindowImp* Imp) { this->_imp = Imp; return *this; };
protected:
	WindowImp * _imp;

};



class IconWindow : public Window { // RefinedAbstractionA
								   // уточнена абстракція для піктограм вікна
public:
	virtual void DrawBorder();
	Window& operator=(WindowImp* Imp) { this->_imp = Imp; return *this; };
protected:
	const char *_bitmapName;
};

void IconWindow::DrawBorder() {
	DrawRect();
	DrawRect();
	DrawRect();
	DrawRect();
	DrawText();
}


class TransistentWindow : public Window // RefinedAbstractionB
										// уточнена абстракція для TransistentWindow
{
public:
	void DrawCloseBox() { DrawRect(); }
	Window& operator=(WindowImp* Imp) { this->_imp = Imp; return *this; };
};


int main()
{
	Window test;
	// реалізуємо вікно для платформи XWindow
	test = new XWindowImp();
	// малюємо рамку
	test.DrawRect();
	// малюємо заголовок
	test.DrawText();


	// реалізуємо вікно для платформи PMWindow
	test = new PMWindowImp();
	// малюємо рамку
	test.DrawRect();
	// малюємо заголовок
	test.DrawText();


	IconWindow IconBox; // піктограма

						// реалізуємо вікно для платформи XWindow
	IconBox = new XWindowImp();
	// малюємо рамку
	IconBox.DrawBorder();


	// реалізуємо вікно для платформи XWindow
	IconBox = new PMWindowImp();
	// малюємо рамку
	IconBox.DrawRect();

	system("pause");
	return 0;
}