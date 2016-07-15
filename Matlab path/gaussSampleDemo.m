% gaussSampleDemo.m
% sample data from a spherical, diagonal and full cov Gaussian in 2D
figure(1); clf
N = 500;
z = 10;

Sigma{1} = [1 0; 0 1];
Sigma{2} = [4 0; 0 1];
Sigma{3} = [4 3; 3 4];
mu = [0 0];
for i=1:3
%x = mvnrnd(mu, Sigma{i}, N);
L = chol(Sigma{i});
x = (L' * randn(2, N))' + repmat(mu, N, 1);
subplot(1,3,i)
plot(x(:,1), x(:,2), '.');
hold on
plot2dgauss(mu(:), Sigma{i}, 'r');
axis([-z z -z z])
axis square
end