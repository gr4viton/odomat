function [current_figure] = set_fig(fig_name)
% sets the current figure to the figure name
set(0,'CurrentFigure', fig_name);
current_figure = fig_name;
