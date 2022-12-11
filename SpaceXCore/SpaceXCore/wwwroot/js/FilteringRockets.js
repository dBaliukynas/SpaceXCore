dselect(document.querySelector("#select-box-rocket-name"), { search: true, clearable: true });

function rocketFilters() {
    return {
        reusableFS: null,
        notReusableFS: null,
        name: null,
        height: null,
        costPerLaunch: null,
        fetchData() {
         
        },
        search() {
            const searchParams = new URLSearchParams();
            const url = "/rockets";

            this.reusableFS && searchParams.set("reusable-fs", this.reusableFS);
            this.notReusableFS && searchParams.set("not-reusable-fs", this.notReusableFS);
            this.name && searchParams.set("name", this.name);
            this.height && searchParams.set("height", this.height);
            this.costPerLaunch && searchParams.set("cost-per-launch", this.costPerLaunch);

            const queryString = searchParams.toString();
            const fullUrl = `${url}?${queryString}`;
            window.location.replace(fullUrl);
        }
    }
}