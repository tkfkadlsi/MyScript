#pragma once
// GameManager
//SAFE_DELETE()
// µø¿˚ ΩÃ±€≈Ê(¥Ÿ¿Ã≥™πÕ ΩÃ±€≈Ê)
// ¡§¿˚ ΩÃ±€≈Ê
#include "Define.h"
//#include "Object.h"
class Core
{
	DECLARE_SINGLE(Core);
public:
	bool Init(HWND _hwnd);
	void GameLoop();
	void CleanUp();
private:
	void MainUpdate();
	void MainRender();
	void CreateGDI();
public:
	const HWND& GetHwnd() const { return m_hWnd; }
	// ¿Ã∏ß πŸ≤Ÿ±‚
	const HDC& GetMainDC() const { return m_hDC; }
	const HBRUSH& GetBrush(BRUSH_TYPE _eType)
	{
		return m_colorBrushs[(UINT)_eType];
	}
	const HPEN& GetPen(PEN_TYPE _eType)
	{
		return m_colorPens[(UINT)_eType];
	}
	std::vector<std::wstring> SplitString(const std::wstring& str, const std::wstring& delimiter)
	{
		std::vector<std::wstring> tokens;
		size_t start = 0;
		size_t end = str.find(delimiter);

		while (end != std::wstring::npos)
		{
			tokens.push_back(str.substr(start, end - start));
			start = end + delimiter.length();
			end = str.find(delimiter, start);
		}

		tokens.push_back(str.substr(start));
		return tokens;
	}
public:
	HFONT ComboFont;
	HFONT ScoreFont;
	HFONT ClassFont;
	HFONT FaSlFont;
private:
	HBRUSH m_colorBrushs[(UINT)BRUSH_TYPE::END] = {};
	HPEN m_colorPens[(UINT)PEN_TYPE::END] = {};

	HWND m_hWnd;
	HDC  m_hDC; // Main DC
	HDC  m_hBackDC; // πÈπˆ∆€ DC
	HBITMAP m_hBackBit; // πÈπˆ∆€¿« bitmap
	//Object m_obj;
	//private:
//	Core() {}
//public:
//	static Core* GetInst()
//	{
//		static Core m_pInst;
//		return &m_pInst;
//	}
//	/*static Core& GetInst2()
//	{
//		static Core m_pInst;
//		return m_pInst;
//	}*/
//
//private:


};
//void test()
//{
//	static int a = 0;
//
//}
// ≈€«√∏¥ ΩÃ±€≈Ê
//class Core 
//{
// //private:
//	static Core* m_pInst;
//public:
//	static Core* GetInst()
//	{
//		if (nullptr == m_pInst)
//			m_pInst = new Core;
//		return m_pInst;
//	}
//	static void DestoryInst()
//	{
//		if (nullptr != m_pInst)
//		{
//
//		}
//	}
//private:
//	Core() {}

//};

