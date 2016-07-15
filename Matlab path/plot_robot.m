function [] = plot_robot(rob)
% draws the "robot"

x = rob.x;
y = rob.y;
th = rob.th;
b = rob.b;
rL = rob.rL;
rR = rob.rR;

%   2r
%  ___
% |  _|  b
% |___|

%  2rL
% A___B
% | S_|  b
% |___|
% C   D
%  2rR

S = [rob.x rob.y];
% A B
scale = sqrt((b/2)^2+rL^2);
phi = atan (b/2/rL);

a = th + phi;
B = [ x + scale*cos(a), y+scale*sin(a)];
a = th - phi + pi;
A = [ x + scale*cos(a), y+scale*sin(a)];

% C D
scale = sqrt((b/2)^2+rR^2);
phi = atan (b/2/rR);

a = th - phi;
D = [ x + scale*cos(a), y+scale*sin(a)];
a = th + phi - pi;
C = [ x + scale*cos(a), y+scale*sin(a)];


plot([A(1) B(1)],[A(2) B(2)], 'color', rob.color1, 'LineStyle', rob.robline);
plot([A(1) C(1)],[A(2) C(2)], 'color', rob.color1, 'LineStyle', rob.robline);
plot([C(1) D(1)],[C(2) D(2)], 'color', rob.color1, 'LineStyle', rob.robline);
plot([B(1) D(1)],[B(2) D(2)], 'color', rob.color1, 'LineStyle', rob.robline);

plot(rob.x, rob.y,'*','color', rob.color1);

% plot([D(1) S(1)],[D(2) S(2)], 'color', rob.color2)
% plot([B(1) S(1)],[B(2) S(2)], 'color', rob.color2)
