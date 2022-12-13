dselect(document.querySelector("#select-box-launch-name"), { search: true, clearable: true });
dselect(document.querySelector("#select-box-launch-rocket-name"), { search: true, clearable: true });

function launchFilters() {
    return {
        name: null,
        rocketName: null,
        succeeded: false,
        notSucceeded: false,
        search() {
            const searchParams = new URLSearchParams();
            const url = "/launches";

            this.name && searchParams.set("name", this.name);
            this.rocketName && searchParams.set("rocket-name", this.rocketName);
            this.succeeded && searchParams.set("succeeded", this.succeeded)
            this.notSucceeded && searchParams.set("not-succeeded", this.notSucceeded)

            const queryString = searchParams.toString();
            const fullUrl = `${url}?${queryString}`;

            window.location.replace(fullUrl);
        }
    }
}