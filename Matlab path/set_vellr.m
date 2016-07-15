function [] = plot_robot(rob)
vell = robot.vellr(1);
velr = robot.vellr(2);
b = robot.base;
r = rob.radius;
th = robot.th;
x0 = robot.pos(1);
y0 = robot.pos(2);

scale = 2;

plot_square(x0, y0, r, rob.color1);
%  ___
% /  _\___
% \___/


plot([x0 x0+r*scale*sin(th)],[x0 x0+r*scale*cos(th)], 'LineColor')