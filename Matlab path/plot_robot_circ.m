function [] = plot_robot_circ(rob)
% draws the "robot"
% b = rob.b;
r = rob.robot_radius;

th = rob.th;
x0 = rob.x;
y0 = rob.y;


% draws a circle of robot
plot_circle(x0, y0, r, rob.color1);


%  ___
% /  _\___
% \___/

% 
% %  _A_
% % / S_\C___
% % \_B_/
% 
% S = [rob.x rob.y];
% 
% scale = 1.5;
% a = th;
% C = [ x0 + r*scale*cos(a), y0+r*scale*sin(a)];
% 
% scale = 1;
% a = th + pi/2;
% A = [ x0 + r*scale*cos(a), y0+r*scale*sin(a)];
% a = th - pi/2;
% B = [ x0 + r*scale*cos(a), y0+r*scale*sin(a)];
% 
% plot([A(1) B(1)],[A(2) B(2)], 'color', [0 0 0])
% plot([A(1) C(1)],[A(2) C(2)], 'color', [0 0 0])
% plot([C(1) B(1)],[C(2) B(2)], 'color', [0 0 0])
% 
% plot([C(1) S(1)],[C(2) S(2)], 'color', [0 0 0])
