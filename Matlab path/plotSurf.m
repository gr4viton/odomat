function plotSurf(mu, S, figndx)
[U,D] = eig(S); % U = eigenvectors, D= diagonal matrix of eigenvalues.
% Evaluate p(x) on a grid.
stepSize = 0.5;
[x,y] = meshgrid(-5:stepSize:5,-5:stepSize:5); % Create grid.
[r,c]=size(x);
% data(k,:) = [x(k) y(k)] for pixel k
data = [x(:) y(:)];
p = mvnpdf(data, mu', S);
p = reshape(p, r, c);
% scale density so it sums to 1
p=p*stepSize^2; % p2(x,y) defeq p(x: x+dx, y: y+ dy) approx p(x,y) dx dy
assert(approxeq(sum(p(:)), 1, 1e-1))
subplot(2,2,figndx)
surfc(x,y,p); % 3D plot
view(-10,50);
xlabel('x','fontsize',15);
ylabel('y','fontsize',15);
zlabel('p(x,y)','fontsize',15);
subplot(2,2,figndx+1)
contour(x,y,p); % Plot contours
axis('square');
xlabel('x','fontsize',15);
ylabel('y','fontsize',15);
% Plot first eigenvector
line([mu(1) mu(1)+sqrt(D(1,1))*U(1,1)],[mu(2) mu(2)+sqrt(D(1,1))*U(2,1)],'linewidth',3)
% Plot second eigenvector
line([mu(1) mu(1)+sqrt(D(2,2))*U(1,2)],[mu(2) mu(2)+sqrt(D(2,2))*U(2,2)],'linewidth',3)