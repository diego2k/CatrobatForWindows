#pragma once

#include "Brick.h"

namespace ProjectStructure
{
	class GlideToBrick :
		public Brick
	{
	public:
		GlideToBrick(FormulaTree *xDestination, FormulaTree *yDestination, FormulaTree *duration, Script* parent);
		void Execute();
	private:
		FormulaTree *m_xDestination;
		FormulaTree *m_yDestination;
		FormulaTree *m_duration;
	};
}