dselect(document.querySelector("#select-box-launch-name"), { search: true, clearable: true });
dselect(document.querySelector("#select-box-launch-rocket-name"), { search: true, clearable: true });

function launchFilters() {
    return {
        name: null,
        rocketName: null,
        fetchData() {
        },
        search() {
            const searchParams = new URLSearchParams();
            const url = "/launches";

            this.name && searchParams.set("name", this.name);
            this.rocketName && searchParams.set("rocket-name", this.rocketName);

            const queryString = searchParams.toString();
            const fullUrl = `${url}?${queryString}`;

            window.location.replace(fullUrl);
        }
    }
}