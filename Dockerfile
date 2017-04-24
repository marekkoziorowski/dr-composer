FROM node:alpine

ENV HOME=/home/app
COPY . $HOME/drcomposer/
WORKDIR $HOME/drcomposer
CMD ["node", "index.js"]