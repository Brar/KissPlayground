SHELL := /bin/bash
YARN := yarn
JS_DIR := assets/js/
VENDOR_DIR := $(JS_DIR)vendor/
JEKYLL := jekyll
UGLIFY := ./node_modules/.bin/uglifyjs -c -m -o

PROJECT_DEPS := package.json

.PHONY: all clean install update include-yarn-deps build serve

all : serve

clean:
	rm -r $(VENDOR_DIR)

install: $(PROJECT_DEPS)
	$(YARN) install

update: $(PROJECT_DEPS)
	$(YARN) upgrade

include-yarn-deps:
	mkdir -p $(VENDOR_DIR)
	cp node_modules/jquery/dist/jquery.slim.min.js $(VENDOR_DIR)
	$(UGLIFY) $(VENDOR_DIR)dependencies.min.js -- node_modules/popper.js/dist/popper.js node_modules/bootstrap/dist/js/bootstrap.js node_modules/oidc-client/dist/oidc-client.js
	$(UGLIFY) $(JS_DIR)app.min.js -- _js/app.js

build: install include-yarn-deps
	$(JEKYLL) build --incremental

serve: install include-yarn-deps
	JEKYLL_ENV=production $(JEKYLL) serve -P 5003
