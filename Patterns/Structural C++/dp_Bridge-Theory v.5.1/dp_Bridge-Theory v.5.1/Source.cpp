#include <iostream>
using namespace std;


class WindowImp { // Implementator - ���������
				  // ������ ��������� ��� ����� Window
public:
	virtual void DevDrawLine() = 0;
	virtual void DevDrawText() = 0;
};


class XWindowImp : public WindowImp { // ConcreteImplementatroA
									  // ��������� ��������� �� �������  XWindow
public:
	void DevDrawText() { cout << "Xtext" << endl; };
	void DevDrawLine() { cout << "Drawing Xline" << endl; }
};


class PMWindowImp : public WindowImp { // ConcreteImplementatroB
	// ��������� ��������� �� �������  PMWindow
public:
	void DevDrawText() { cout << "PMtext" << endl; };
	void DevDrawLine() { cout << "Drawing PMWindow line..." << endl; }
};



class Window // Abstraction
			 // ��������� ��� �����������
{
public:
	void DrawText() { _imp->DevDrawText(); }
	void DrawRect() { _imp->DevDrawLine(); }
	Window& operator=(WindowImp* Imp) { this->_imp = Imp; return *this; };
protected:
	WindowImp * _imp;

};



class IconWindow : public Window { // RefinedAbstractionA
								   // �������� ���������� ��� �������� ����
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
										// �������� ���������� ��� TransistentWindow
{
public:
	void DrawCloseBox() { DrawRect(); }
	Window& operator=(WindowImp* Imp) { this->_imp = Imp; return *this; };
};


int main()
{
	Window test;
	// �������� ���� ��� ��������� XWindow
	test = new XWindowImp();
	// ������� �����
	test.DrawRect();
	// ������� ���������
	test.DrawText();


	// �������� ���� ��� ��������� PMWindow
	test = new PMWindowImp();
	// ������� �����
	test.DrawRect();
	// ������� ���������
	test.DrawText();


	IconWindow IconBox; // ���������

						// �������� ���� ��� ��������� XWindow
	IconBox = new XWindowImp();
	// ������� �����
	IconBox.DrawBorder();


	// �������� ���� ��� ��������� XWindow
	IconBox = new PMWindowImp();
	// ������� �����
	IconBox.DrawRect();

	system("pause");
	return 0;
}