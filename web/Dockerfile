FROM node:lts-alpine
WORKDIR /web
COPY . .
RUN yarn install
RUN chmod +x /web/entrypoint.sh

ENTRYPOINT ["sh", "entrypoint.sh"]

