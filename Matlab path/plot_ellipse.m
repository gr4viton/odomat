function [out] = plot_ellipse(posx, posy, xrad, yrad, col)
%  draws an ellipse

rectangle('Position',[posx-xrad, posy-yrad, 2*xrad, 2*yrad],...
    'Curvature',[1,1]);
% ,...
%     'FaceColor',col);
out = 1;